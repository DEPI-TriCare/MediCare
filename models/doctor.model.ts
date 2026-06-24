export interface DoctorDto {
  id: number;
  name: string;
  email: string;
  phone: string;
  specializationId: number;
  consultationFee: number;
}

export interface CreateDoctorDto {
  name: string;
  email: string;
  phone: string;
  passwordHash: string;
  specializationId: number;
  consultationFee: number;
}

export interface UpdateDoctorDto {
  name: string;
  email: string;
  phone: string;
  specializationId: number;
  consultationFee: number;
}