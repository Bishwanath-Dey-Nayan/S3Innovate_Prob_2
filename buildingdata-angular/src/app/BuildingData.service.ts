import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { forkJoin } from 'rxjs';

@Injectable({providedIn:'root'})
export class BuildingService{
    building:any = [];
    object:any = [];
    datafield:any = [];
    filteredData: any =[]

    constructor(private http: HttpClient){}
    initialize()
    {
        this.fetchBuilding();
        this.fetchObject();
        this.fetchDataField();
    }

    fetchBuilding()
    {
       return this.http.get('https://localhost:44395/api/Building');
    }

    fetchObject()
    {
       return this.http.get('https://localhost:44395/api/Object');
    }

    fetchDataField()
    {
       return this.http.get('https://localhost:44395/api/DataField');
    }

    fetchSearch(building, object,datafield,startdate,enddate)
    {
       console.log('fetched');
      let params = new HttpParams();
      params = params.append('buildingId', building);
      params = params.append('objectDataId', object);
      params = params.append('dataFieldId', datafield);
      params = params.append('startDate', startdate);
      params = params.append('endDate', enddate);
      return this.http.get('https://localhost:44395/api/ReadingData/Search',{
         params:params
      })
      // .subscribe(res => {
      // this.filteredData = res;
      // console.log(this.filteredData)
      // });
    }
}