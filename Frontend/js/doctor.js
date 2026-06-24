if (localStorage.getItem("userRole") !== "doctor") {
    alert("Access Denied! Please login as a Doctor.");
    window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", async function () {
    const tbody = document.getElementById("docApptsBody");
    const currentDoctorId = localStorage.getItem("userId");

    if (tbody) {
        try {
            const appts = await AppointmentService.getAll();
            tbody.innerHTML = "";
            
            const myAppts = appts.filter(a => a.doctorId === parseInt(currentDoctorId));

            if (myAppts.length === 0) {
                tbody.innerHTML = "<tr><td colspan='3'>No upcoming appointments scheduled for you.</td></tr>";
            } else {
                myAppts.forEach(a => {
                    tbody.innerHTML += `
                        <tr>
                            <td>Patient ID: #${a.patientId}</td>
                            <td>${a.time || '11:00 AM'}</td>
                            <td>General Checkup</td>
                        </tr>`;
                });
            }
        } catch (e) {
            tbody.innerHTML = "<tr><td colspan='3' style='color:red;'>Error loading your schedules from server.</td></tr>";
        }
    }

    const recordForm = document.getElementById("recordForm");
    if (recordForm) {
        recordForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            const patientId = document.getElementById("pId").value;
            const diagnosis = document.getElementById("diag").value;
            const submitBtn = recordForm.querySelector(".btn");
            
            submitBtn.innerText = "Saving Record...";
            submitBtn.disabled = true;

            try {
                await MedicalRecordService.create({ 
                    patientId: parseInt(patientId), 
                    doctorId: parseInt(currentDoctorId), 
                    diagnosis: diagnosis 
                });
                alert("Medical Record Created and Saved to Database successfully!");
                recordForm.reset();
            } catch (err) {
                alert("Failed to save record: " + err.message);
            } finally {
                submitBtn.innerText = "Submit Medical Report";
                submitBtn.disabled = false;
            }
        });
    }
});