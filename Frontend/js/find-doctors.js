if (localStorage.getItem("userRole") !== "patient") {
    alert("Access Denied! Please login as a Patient.");
    window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", async function () {
    const grid = document.getElementById("doctorsGrid");
    if (grid) {
        try {
            const docs = await DoctorService.getAll();
            grid.innerHTML = "";
            if (docs.length === 0) {
                grid.innerHTML = "<p>No registered doctors found.</p>";
                return;
            }
            docs.forEach(d => {
                grid.innerHTML += `
                    <div class="doctor-card">
                        <h4>${d.name}</h4>
                        <p><strong>Doctor ID:</strong> ${d.id}</p>
                        <p><strong>Consultation Fee:</strong> $${d.consultationFee}</p>
                    </div>`;
            });
        } catch (e) {
            grid.innerHTML = "<p style='color:red;'>Error fetching doctors from server.</p>";
        }
    }

    const bookForm = document.getElementById("bookForm");
    if (bookForm) {
        bookForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            const docId = document.getElementById("docIdInput").value;
            const bookingDate = document.getElementById("bookingDate").value;
            const bookingTime = document.getElementById("bookingTime").value;
            const submitBtn = bookForm.querySelector(".btn");
            const currentPatientId = localStorage.getItem("userId");

            submitBtn.innerText = "Booking Form...";
            submitBtn.disabled = true;

            try {
                await AppointmentService.create({ 
                    patientId: parseInt(currentPatientId), 
                    doctorId: parseInt(docId), 
                    date: bookingDate, 
                    time: bookingTime 
                });
                alert("Booked Successfully!");
                window.location.href = "patient-overview.html";
            } catch (err) {
                alert("Booking failed: " + err.message);
                submitBtn.innerText = "Confirm Booking";
                submitBtn.disabled = false;
            }
        });
    }
});