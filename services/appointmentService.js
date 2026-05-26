const APPOINTMENT_API_URL = 'http://localhost:5000/api/Appointments';

const AppointmentService = {
    async getAll() {
        const response = await fetch(APPOINTMENT_API_URL);
        if (!response.ok) throw new Error('Network error');
        return await response.json();
    },
    async create(appointmentDto) {
        const response = await fetch(APPOINTMENT_API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(appointmentDto)
        });
        if (!response.ok) throw new Error('Action failed');
        return await response.json();
    }
};