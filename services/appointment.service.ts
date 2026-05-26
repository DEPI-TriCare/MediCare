import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppointmentDto, CreateAppointmentDto, UpdateAppointmentDto } from '../models/appointment.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  private apiUrl = 'http://localhost:5000/api/Appointments';

  constructor(private http: HttpClient) {}

  getAll(): Observable<AppointmentDto[]> {
    return this.http.get<AppointmentDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<AppointmentDto> {
    return this.http.get<AppointmentDto>(this.apiUrl + '/' + id);
  }

  create(dto: CreateAppointmentDto): Observable<AppointmentDto> {
    return this.http.post<AppointmentDto>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAppointmentDto): Observable<AppointmentDto> {
    return this.http.put<AppointmentDto>(this.apiUrl + '/' + id, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/' + id);
  }
}