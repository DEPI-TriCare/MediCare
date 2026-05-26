const MEDICAL_RECORD_API_URL = 'http://localhost:5000/api/MedicalRecords';

const MedicalRecordService = {
    async getAll() {
        const response = await fetch(MEDICAL_RECORD_API_URL);
        if (!response.ok) throw new Error('Network error');
        return await response.json();
    },
    async create(recordDto) {
        const response = await fetch(MEDICAL_RECORD_API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(recordDto)
        });
        if (!response.ok) throw new Error('Action failed');
        return await response.json();
    }
};