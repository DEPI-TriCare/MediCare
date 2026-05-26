if (localStorage.getItem("userRole") !== "patient") {
    alert("Access Denied!");
    window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", async function () {
    const tbody = document.getElementById("recordsTableBody");
    if (!tbody) return;

    try {
        const records = await MedicalRecordService.getAll();
        tbody.innerHTML = "";
        
        if (records.length === 0) {
            tbody.innerHTML = "<tr><td colspan='3'>No medical records available in your history.</td></tr>";
            return;
        }

        records.forEach(r => {
            tbody.innerHTML += `
                <tr>
                    <td>#${r.id}</td>
                    <td>${r.diagnosis}</td>
                    <td>Doctor ID: ${r.doctorId}</td>
                </tr>`;
        });
    } catch (e) {
        tbody.innerHTML = "<tr><td colspan='3' style='color:red; text-align:center;'>Failed to connect to medical records service.</td></tr>";
    }
});