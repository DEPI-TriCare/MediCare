export interface PatientDto {
  id: number;
  name: string;
  email: string;
  phone: string;
  allergies: string;
  medicalHistory: string;
}

export interface CreatePatientDto {
  name: string;
  email: string;
  phone: string;
  passwordHash: string;
  allergies: string;
  medicalHistory: string;
}

export interface UpdatePatientDto {
  name: string;
  email: string;
  phone: string;
  allergies: string;
  medicalHistory: string;
}