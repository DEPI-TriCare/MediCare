const WORKING_HOURS_API_URL = 'http://localhost:5000/api/WorkingHours';

const WorkingHourService = {
    async getAll() {
        const response = await fetch(WORKING_HOURS_API_URL);
        if (!response.ok) throw new Error('Network error');
        return await response.json();
    }
};