document.addEventListener("DOMContentLoaded", function () {
    const signupForm = document.getElementById("signupForm");
    if (signupForm) {
        signupForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            const name = document.getElementById("regName").value;
            const email = document.getElementById("regEmail").value;
            const password = document.getElementById("regPassword").value;
            const role = document.getElementById("regRole").value;
            const submitBtn = signupForm.querySelector(".btn");

            submitBtn.innerText = "Registering...";
            submitBtn.disabled = true;

            try {
                if (role === "patient") {
                    await PatientService.create({ 
                        name: name, 
                        email: email, 
                        phone: "01000000000", 
                        passwordHash: password, 
                        allergies: "None", 
                        medicalHistory: "None" 
                    });
                } else {
                    await DoctorService.create({ 
                        name: name, 
                        email: email, 
                        phone: "01100000000", 
                        passwordHash: password, 
                        specializationId: 1, 
                        consultationFee: 100 
                    });
                }
                alert("Account Created Successfully!");
                window.location.href = "index.html";
            } catch (err) {
                alert("Registration Failed: " + err.message);
            } finally {
                submitBtn.innerText = "Register";
                submitBtn.disabled = false;
            }
        });
    }
});