import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Point } from '../models/point';

@Injectable({
  providedIn: 'root'
})
export class PointsService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
   }

  public GetPoints(): Observable<Point[]> {
    return this.http.get<Point[]>("https://localhost:44328/Point");
  }

  public AddPoint(point:Point): Observable<Point>{
    return this.http.post<Point>("https://localhost:44328/Point", point);
  }

  public GetPointById(id: number): Observable<Point> {
    return this.http.get<Point>(`https://localhost:44328/Point/${id}`);
  }

  public PrintHello() :void {
    console.log("Hello from service");
  }
}
