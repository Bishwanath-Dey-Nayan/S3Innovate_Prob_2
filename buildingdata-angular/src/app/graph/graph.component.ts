import { Component, EventEmitter, Input, OnInit } from "@angular/core";
import {BuildingService} from '../BuildingData.service';
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
import { dataSeries } from "./data-series";

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent implements OnInit {
  graphData:any[] = [];
  @Input() searchData: EventEmitter<any[]>;

  public series: ApexAxisChartSeries;
  public chart: ApexChart;
  public dataLabels: ApexDataLabels;
  public markers: ApexMarkers;
  public title: ApexTitleSubtitle;
  public fill: ApexFill;
  public yaxis: ApexYAxis;
  public xaxis: ApexXAxis;
  public tooltip: ApexTooltip;

  constructor( private buildingService: BuildingService) {
    this.initChartData();
  }

  ngOnInit()
  {
    this.searchData.subscribe(data => {
      console.log('data',data)
    })

    // if(this.searchData){
 
    // }

  }

  public initChartData(): void {
    let dates = [];
    for (let i = 0; i < 120; i++) {
      //dates.push([dataSeries[i].timestamp, dataSeries[i].value]);
      dates.push([dataSeries[i].date, dataSeries[i].value]);
      console.log('dataseries',this.graphData)
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
        shadeIntensity: 1,
        inverseColors: false,
        opacityFrom: 0.5,
        opacityTo: 0,
        stops: [0, 90, 100]
      }
    };
    this.yaxis = {
      labels: {
        formatter: function(val) {
          return (val / 1000000).toFixed(0);
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
          return (val / 1000000).toFixed(0);
        }
      }
    };
  }

}
