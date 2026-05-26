import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkingHourDto, CreateWorkingHourDto, UpdateWorkingHourDto } from '../models/working-hour.model';

@Injectable({
  providedIn: 'root'
})
export class WorkingHourService {
  private apiUrl = 'http://localhost:5000/api/WorkingHours';

  constructor(private http: HttpClient) {}

  getAll(): Observable<WorkingHourDto[]> {
    return this.http.get<WorkingHourDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<WorkingHourDto> {
    return this.http.get<WorkingHourDto>(this.apiUrl + '/' + id);
  }

  create(dto: CreateWorkingHourDto): Observable<WorkingHourDto> {
    return this.http.post<WorkingHourDto>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateWorkingHourDto): Observable<WorkingHourDto> {
    return this.http.put<WorkingHourDto>(this.apiUrl + '/' + id, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/' + id);
  }
}