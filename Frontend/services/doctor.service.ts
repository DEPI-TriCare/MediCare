import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DoctorDto, CreateDoctorDto, UpdateDoctorDto } from '../models/doctor.model';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private apiUrl = 'http://localhost:5000/api/Doctors';

  constructor(private http: HttpClient) {}

  getAll(): Observable<DoctorDto[]> {
    return this.http.get<DoctorDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<DoctorDto> {
    return this.http.get<DoctorDto>(this.apiUrl + '/' + id);
  }

  create(dto: CreateDoctorDto): Observable<DoctorDto> {
    return this.http.post<DoctorDto>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateDoctorDto): Observable<DoctorDto> {
    return this.http.put<DoctorDto>(this.apiUrl + '/' + id, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/' + id);
  }
}