import { Component, OnInit } from '@angular/core';

import { DataDTO } from './data';
import { Data } from './data';
import { DataService } from './data.service';

@Component({
  selector:    'app-data-table',
  templateUrl: './data-table.component.html',
  providers:  [ DataService ]
})
export class DataTableComponent implements OnInit {
  datas: Data = {
    result: [],
    success: true,
    message: "",
    errors: []
};

  displayedColumns : any[] = ['name','lastName', 'postCode', 'city', 'phoneNumber'];
  invalidFormat: boolean = false;
  constructor(private service: DataService) { }

  ngOnInit() {
    //this.getDatas();
  }

  getDatas(): void {
    this.service.getDatas()
    .subscribe((data) => {this.datas = {
      result: data['result'],
      errors:  data['errors'],
      success: data['success'],
      message: data['message']
    }; }, 
    (error) => {console.log(error)});
  }

  saveDatas(datas: Data) : void{
    this.service.saveDatas(datas.result)
      .subscribe((data) => {this.datas = {
        result: data['result'],
        errors:  data['errors'],
        success: data['success'],
        message: data['message']
      };}, 
      (error) => {console.log(error)});
  }

}
