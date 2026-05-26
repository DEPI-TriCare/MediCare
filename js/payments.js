if (localStorage.getItem("userRole") !== "patient") {
    alert("Access Denied!");
    window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", function () {
    const checkoutForm = document.getElementById("checkoutForm");
    
    if (checkoutForm) {
        checkoutForm.addEventListener("submit", async function (e) {
            e.preventDefault(); 

            const cardNumber = document.getElementById("cardNumber").value.replace(/\s+/g, '');
            const cvv = document.getElementById("cvv").value;
            const expDate = document.getElementById("expDate").value;
            const submitBtn = checkoutForm.querySelector(".btn-pay");

            if (cardNumber.length !== 16 || isNaN(cardNumber)) {
                alert("Error: Card number must be exactly 16 digits.");
                return;
            }
            if (cvv.length !== 3 || isNaN(cvv)) {
                alert("Error: CVV must be exactly 3 digits.");
                return;
            }

            const expPattern = /^(0[1-9]|1[0-2])\/?([0-9]{2})$/;
            if (!expPattern.test(expDate)) {
                alert("Error: Expiry date must be in MM/YY format (e.g., 05/29).");
                return;
            }

            const paymentData = {
                patientId: parseInt(localStorage.getItem("userId")), 
                amount: 150.00,
                cardholderName: document.getElementById("cardName").value,
                cardNumber: cardNumber,
                expiryDate: expDate,
                cvv: cvv
            };

            submitBtn.innerText = "Processing Transaction...";
            submitBtn.disabled = true;

            try {
                const response = await fetch('http://localhost:5000/api/Payments/charge', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(paymentData)
                });

                if (!response.ok) throw new Error('Payment Declined by Bank API');

                alert("Payment Successful! Connection secured.");
                updateUIToPaid();

            } catch (error) {
                alert("Transaction Failed: " + error.message);
                submitBtn.innerText = "Pay Invoice Now";
                submitBtn.disabled = false;
            }
        });
    }
});

function updateUIToPaid() {
    const balanceAmount = document.getElementById("balanceAmount");
    const paymentFormContainer = document.getElementById("paymentFormContainer");
    const invoiceCard = document.querySelector(".invoice-card");

    if (balanceAmount) balanceAmount.innerHTML = `$0.00 <span class="badge-paid">SUCCESSFULLY PAID</span>`;
    if (invoiceCard) invoiceCard.style.borderLeftColor = "#28a745"; 
    if (paymentFormContainer) {
        paymentFormContainer.innerHTML = `
            <div style="text-align: center; padding: 20px; color: #28a745;">
                <h4 style="margin: 0;">✓ Payment Confirmed</h4>
                <p style="color: #666; margin-top: 5px; font-size: 14px;">The invoice has been processed and saved securely.</p>
            </div>`;
    }
}