export interface TreatmentItemDto {
  id: number;
  medicineName: string;
  dose: number;
  timesPerDay: number;
}

export interface CreateTreatmentItemDto {
  medicineName: string;
  dose: number;
  timesPerDay: number;
}

export interface UpdateTreatmentItemDto {
  medicineName: string;
  dose: number;
  timesPerDay: number;
}