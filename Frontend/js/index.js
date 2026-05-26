localStorage.clear();

document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("loginForm");
    if (loginForm) {
        loginForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            
            const email = document.getElementById("email").value;
            const password = document.getElementById("password").value;
            const role = document.getElementById("role").value;
            const submitBtn = loginForm.querySelector(".btn");

            if (email === "medicare@gmail.com" && password === "medicare6") {
                localStorage.setItem("userId", "1");
                localStorage.setItem("userName", "hasnaa");
                localStorage.setItem("userRole", role);

                if (role === "patient") window.location.href = "patient-overview.html";
                else if (role === "doctor") window.location.href = "doctor.html";
                else if (role === "receptionist") window.location.href = "reception.html";
                return;
            }

            submitBtn.innerText = "Signing In...";
            submitBtn.disabled = true;

            try {
                const response = await fetch('http://localhost:5000/api/Auth/login', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ email, password, role })
                });

                if (!response.ok) throw new Error('Invalid Credentials');

                const user = await response.json();

                localStorage.setItem("userId", user.id);
                localStorage.setItem("userName", user.name);
                localStorage.setItem("userRole", role);

                if (role === "patient") window.location.href = "patient-overview.html";
                else if (role === "doctor") window.location.href = "doctor.html";
                else if (role === "receptionist") window.location.href = "reception.html";

            } catch (err) {
                alert("Login Failed: " + err.message);
                submitBtn.innerText = "Sign In";
                submitBtn.disabled = false;
            }
        });
    }
});