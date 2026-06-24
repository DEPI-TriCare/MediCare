import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicalRecordDto, CreateMedicalRecordDto, UpdateMedicalRecordDto } from '../models/medical-record.model';

@Injectable({
  providedIn: 'root'
})
export class MedicalRecordService {
  private apiUrl = 'http://localhost:5000/api/MedicalRecords';

  constructor(private http: HttpClient) {}

  getAll(): Observable<MedicalRecordDto[]> {
    return this.http.get<MedicalRecordDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<MedicalRecordDto> {
    return this.http.get<MedicalRecordDto>(this.apiUrl + '/' + id);
  }

  create(dto: CreateMedicalRecordDto): Observable<MedicalRecordDto> {
    return this.http.post<MedicalRecordDto>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateMedicalRecordDto): Observable<MedicalRecordDto> {
    return this.http.put<MedicalRecordDto>(this.apiUrl + '/' + id, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/' + id);
  }
}