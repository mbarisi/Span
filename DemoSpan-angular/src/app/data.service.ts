import { Injectable, Type } from '@angular/core';

import { Logger } from './logger.service';
import { DataDTO } from './data';
import { catchError, Observable, of, tap, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Data } from '@angular/router';


@Injectable()
export class DataService {
  private dataUrl = 'https://localhost:7259/data'; 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private logger: Logger, private http: HttpClient) {}

  getDatas(): Observable<Data> {
    return this.http.get<Data>(this.dataUrl)
      .pipe(
        tap(_=> this.logger.log('fetched data')),
        catchError(this.handleError)
      );
  }

  saveDatas(dataDTOs: DataDTO[]): Observable<Data> {
    return this.http.post<DataDTO[]>(this.dataUrl+'/insert', dataDTOs, this.httpOptions).pipe(
      tap((newDataDTOs: DataDTO[]) =>  this.logger.log(`added datas`)),
      catchError(this.handleError)
    );
  }

  handleError(error: HttpErrorResponse) {
    return throwError(() => new Error("Bad request"));
}
}
