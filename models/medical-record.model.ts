export interface MedicalRecordDto {
  id: number;
  patientId: number;
  doctorId: number;
  diagnosis: string;
  createdAt: string;
}

export interface CreateMedicalRecordDto {
  patientId: number;
  doctorId: number;
  diagnosis: string;
}

export interface UpdateMedicalRecordDto {
  diagnosis: string;
}