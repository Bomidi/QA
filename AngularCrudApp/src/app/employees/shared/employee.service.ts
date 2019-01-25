import { Injectable } from '@angular/core';

import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';  //  '@angular/http';
//import {HttpClientModule} from '@angular/common/http';

//import {HttpClientModule} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import {environment} from '../../../environments/environment'



import { from } from 'rxjs/internal/observable/from';
import {Employee} from'./employee.model'

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  api_URL: string= environment.serverUrl;
  selectedEmployee : Employee;
  employeeList : Employee[];

  constructor(public http : Http) { }

  postEmployee(emp : Employee){
    var body =  JSON.stringify(emp);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post(this.api_URL,body,requestOptions).map(x => x.json());
  }
 
  putEmployee(id, emp) {
    var body = JSON.stringify(emp);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put(this.api_URL+ id,
      body,
      requestOptions).map(res => res.json());
  }
 
  getEmployeeList(){
    this.http.get(this.api_URL)
    .map((data : Response) =>{
      return data.json() as Employee[];
    }).toPromise().then(x => {
      this.employeeList = x;
    })
  }
 
  deleteEmployee(id: number) {
    return this.http.delete(this.api_URL + id).map(res => res.json());
  }

}
