import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Time } from '../_models/Time';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimeService {

  baseURL = 'http://localhost:5000/api/time';

  constructor(private http: HttpClient) { }

  getAllTimes(): Observable<Time[]> {
    return this.http.get<Time[]>(this.baseURL);
  }

  getTimeById(timeId: number): Observable<Time> {
    return this.http.get<Time>(`${this.baseURL}/${timeId}`);
  }

  postTime(time: Time) {
    return this.http.post(this.baseURL, time);
  }

  putTime(time: Time) {
    return this.http.put(`${this.baseURL}/${time.timeId}`, time);
  }

  deleteTime(timeId: number) {
    return this.http.delete(`${this.baseURL}/${timeId}`);
  }

}
