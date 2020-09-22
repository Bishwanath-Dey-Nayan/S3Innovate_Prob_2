import { Component, EventEmitter, OnInit } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BuildingService } from './BuildingData.service';
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexTitleSubtitle,
  ApexDataLabels,
  ApexFill,
  ApexMarkers,
  ApexYAxis,
  ApexXAxis,
  ApexTooltip
} from "ng-apexcharts";
import { dataSeries } from "./graph/data-series";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  buildingData: any = [];
  objectData: any = [];
  dataFieldData: any = [];
  filteredData: any =[]
  //searchData: EventEmitter<any[]> = new EventEmitter();

  public series: ApexAxisChartSeries;
  public chart: ApexChart;
  public dataLabels: ApexDataLabels;
  public markers: ApexMarkers;
  public title: ApexTitleSubtitle;
  public fill: ApexFill;
  public yaxis: ApexYAxis;
  public xaxis: ApexXAxis;
  public tooltip: ApexTooltip;

  constructor(private buildingService:BuildingService){
 
  }


  ngOnInit(){
    this.initChartData();
    this.buildingService.fetchBuilding().subscribe(res =>{
      this.buildingData = res
    })
    this.buildingService.fetchDataField().subscribe(res =>{
      this.dataFieldData = res;
    })
    this.buildingService.fetchObject().subscribe(res =>{
      this.objectData = res;
    })

  }
  public initChartData(): void {
    console.log('Init Chart',this.filteredData)
    let dates = [];
    for (let i = 0; i < this.filteredData.length; i++) {
      dates.push([this.filteredData[i].timestamp, this.filteredData[i].value]);
      //dates.push([dataSeries[i].date, dataSeries[i].value]);
      console.log('dataseries',this.filteredData)
    }

    this.series = [
      {
        name: "Building Reading",
        data: dates
      }
    ];
    this.chart = {
      type: "area",
      stacked: false,
      height: 400,
      zoom: {
        type: "x",
        enabled: true,
        autoScaleYaxis: true
      },
      toolbar: {
        autoSelected: "zoom"
      }
    };
    this.dataLabels = {
      enabled: false
    };
    this.markers = {
      size: 0
    };
    this.title = {
      text: "Time Series Data",
      align: "left"
    };
    this.fill = {
      type: "gradient",
      gradient: {
        shadeIntensity: 0,
        inverseColors: false,
        opacityFrom: 0.5,
        opacityTo: 0,
        stops: [0, 90, 100]
      }
    };
    this.yaxis = {
      labels: {
        formatter: function(val) {
          return (val).toFixed(0);
        }
      },
      title: {
        text: "value"
      }
    };
    this.xaxis = {
      type: "datetime"
    };
    this.tooltip = {
      shared: false,
      y: {
        formatter: function(val) {
          return (val).toFixed(0);
        }
      }
    };
  }
  onSearchClick(building, object, datafield, startdate, enddate)
  {
    console.log(building,object,datafield,startdate,enddate)
    this.buildingService.fetchSearch(building, object,datafield,startdate,enddate).subscribe(
      res =>{
          this.filteredData = res;
          //console.log(res)
          this.ngOnInit();
      }
    );
    //this.searchData.emit(this.filteredData)
  }

}
