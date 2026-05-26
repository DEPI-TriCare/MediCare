if (localStorage.getItem("userRole") !== "receptionist") {
    alert("Access Denied!");
    window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", async function () {
    const tbody = document.getElementById("patientsTableBody");
    
    async function loadPatients() {
        if (!tbody) return;
        try {
            const patients = await PatientService.getAll();
            tbody.innerHTML = "";
            if (patients.length === 0) {
                tbody.innerHTML = "<tr><td colspan='4'>No patients registered yet.</td></tr>";
                return;
            }
            patients.forEach(p => {
                tbody.innerHTML += `
                    <tr>
                        <td>${p.id}</td>
                        <td>${p.name}</td>
                        <td>${p.email}</td>
                        <td>${p.phone}</td>
                    </tr>`;
            });
        } catch (e) {
            tbody.innerHTML = "<tr><td colspan='4' style='color:red;'>Error fetching database registry.</td></tr>";
        }
    }

    await loadPatients();

    const registerPatientForm = document.getElementById("registerPatientForm");
    if (registerPatientForm) {
        registerPatientForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            const submitBtn = registerPatientForm.querySelector(".btn");
            
            const newPatient = {
                name: document.getElementById("pName").value,
                email: document.getElementById("pEmail").value,
                phone: document.getElementById("pPhone").value,
                passwordHash: "123456", 
                allergies: "None",
                medicalHistory: "None"
            };

            submitBtn.innerText = "Creating...";
            submitBtn.disabled = true;

            try {
                await PatientService.create(newPatient);
                alert("Patient Registered successfully in Database!");
                registerPatientForm.reset();
                await loadPatients(); 
            } catch (err) {
                alert("Failed to create patient: " + err.message);
            } finally {
                submitBtn.innerText = "Create Patient Account";
                submitBtn.disabled = false;
            }
        });
    }

    const recBookForm = document.getElementById("recBookForm");
    if (recBookForm) {
        recBookForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            const submitBtn = recBookForm.querySelector(".btn-green");
            const recDate = document.getElementById("recDate").value;
            const recTime = document.getElementById("recTime").value;

            submitBtn.innerText = "Generating...";
            submitBtn.disabled = true;

            try {
                await AppointmentService.create({ 
                    patientId: parseInt(document.getElementById("recPId").value), 
                    doctorId: parseInt(document.getElementById("recDId").value), 
                    date: recDate, 
                    time: recTime 
                });
                alert("Appointment Form Generated successfully!");
                recBookForm.reset();
            } catch (err) {
                alert("Booking failed: " + err.message);
            } finally {
                submitBtn.innerText = "Generate Appointment";
                submitBtn.disabled = false;
            }
        });
    }
});