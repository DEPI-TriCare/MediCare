import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PatientDto, CreatePatientDto, UpdatePatientDto } from '../models/patient.model';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private apiUrl = 'http://localhost:5000/api/Patients';

  constructor(private http: HttpClient) {}

  getAll(): Observable<PatientDto[]> {
    return this.http.get<PatientDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<PatientDto> {
    return this.http.get<PatientDto>(this.apiUrl + '/' + id);
  }

  create(dto: CreatePatientDto): Observable<PatientDto> {
    return this.http.post<PatientDto>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdatePatientDto): Observable<PatientDto> {
    return this.http.put<PatientDto>(this.apiUrl + '/' + id, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/' + id);
  }
}