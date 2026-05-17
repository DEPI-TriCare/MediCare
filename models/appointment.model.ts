export interface AppointmentDto {
  id: number;
  patientId: number;
  doctorId: number;
  date: string;
  time: string;
  status: string;
}

export interface CreateAppointmentDto {
  patientId: number;
  doctorId: number;
  date: string;
  time: string;
}

export interface UpdateAppointmentDto {
  date: string;
  time: string;
  status: string;
}