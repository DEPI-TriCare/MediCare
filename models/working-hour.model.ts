export interface WorkingHourDto {
  id: number;
  doctorId: number;
  dayOfWeek: string;
  startTime: string;
  endTime: string;
}

export interface CreateWorkingHourDto {
  doctorId: number;
  dayOfWeek: string;
  startTime: string;
  endTime: string;
}

export interface UpdateWorkingHourDto {
  dayOfWeek: string;
  startTime: string;
  endTime: string;
}