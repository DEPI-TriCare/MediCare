if (localStorage.getItem("userRole") !== "patient") {
    alert("Access Denied!");
    window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", async function () {
    const list = document.getElementById("appointmentsList");
    const welcomeHeading = document.querySelector(".content h2");
    if (!list) return;

    const currentUserName = localStorage.getItem("userName");
    if (welcomeHeading && currentUserName) {
        welcomeHeading.innerText = `Welcome back, ${currentUserName}!`;
    }

    const currentPatientId = localStorage.getItem("userId");

    try {
        const data = await AppointmentService.getAll();
        list.innerHTML = "";
        
        const myAppointments = data.filter(a => a.patientId === parseInt(currentPatientId));

        if (myAppointments.length === 0) {
            list.innerHTML = "<p>No upcoming schedules found in your account.</p>";
            return;
        }

        myAppointments.forEach(a => {
            list.innerHTML += `
                <div class="appt-item">
                    <h4>Appointment ID: #${a.id}</h4>
                    <p>Doctor ID: ${a.doctorId} | Time: ${a.time || '10:00 AM'}</p>
                </div>`;
        });
    } catch (e) {
        list.innerHTML = "<p style='color:red;'>Unable to load your appointments at this moment.</p>";
    }
});