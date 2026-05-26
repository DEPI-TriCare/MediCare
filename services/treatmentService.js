const TREATMENT_API_URL = 'http://localhost:5000/api/Treatments';

const TreatmentService = {
    async getAll() {
        const response = await fetch(TREATMENT_API_URL);
        if (!response.ok) throw new Error('Network error');
        return await response.json();
    }
};