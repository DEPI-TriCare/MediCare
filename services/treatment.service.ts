import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TreatmentItemDto, CreateTreatmentItemDto, UpdateTreatmentItemDto } from '../models/treatment.model';

@Injectable({
  providedIn: 'root'
})
export class TreatmentService {
  private apiUrl = 'http://localhost:5000/api/Treatments';

  constructor(private http: HttpClient) {}

  getAll(): Observable<TreatmentItemDto[]> {
    return this.http.get<TreatmentItemDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<TreatmentItemDto> {
    return this.http.get<TreatmentItemDto>(this.apiUrl + '/' + id);
  }

  create(dto: CreateTreatmentItemDto): Observable<TreatmentItemDto> {
    return this.http.post<TreatmentItemDto>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateTreatmentItemDto): Observable<TreatmentItemDto> {
    return this.http.put<TreatmentItemDto>(this.apiUrl + '/' + id, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/' + id);
  }
}