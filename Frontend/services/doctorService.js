const DOCTOR_API_URL = 'http://localhost:5000/api/Doctors';

const DoctorService = {
    async getAll() {
        const response = await fetch(DOCTOR_API_URL);
        if (!response.ok) throw new Error('Network error');
        return await response.json();
    },
    async getById(id) {
        const response = await fetch(`${DOCTOR_API_URL}/${id}`);
        if (!response.ok) throw new Error('Not found');
        return await response.json();
    },
    async create(doctorDto) {
        const response = await fetch(DOCTOR_API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(doctorDto)
        });
        if (!response.ok) throw new Error('Action failed');
        return await response.json();
    }
};