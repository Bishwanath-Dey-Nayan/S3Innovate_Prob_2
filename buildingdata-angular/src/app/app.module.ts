import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {BuildingService} from './BuildingData.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgModule } from '@angular/core';
import {DemoMaterialModule} from './material.module';
import { MatNativeDateModule } from '@angular/material/core';
import { AppComponent } from './app.component';
import {MAT_FORM_FIELD_DEFAULT_OPTIONS} from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FusionChartsModule } from 'angular-fusioncharts';
import { NgApexchartsModule } from "ng-apexcharts";

// Load FusionCharts
import * as FusionCharts from 'fusioncharts';
// Load Charts module
import * as Charts from 'fusioncharts/fusioncharts.charts';
// Load themes
import * as FusionTheme from 'fusioncharts/themes/fusioncharts.theme.fusion';
import { GraphComponent } from './graph/graph.component';

// Add dependencies to FusionChartsModule
FusionChartsModule.fcRoot(
  FusionCharts,
  Charts,
  FusionTheme
)

@NgModule({
  declarations: [
    AppComponent,
    GraphComponent
  ],
  imports: [
    HttpClientModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatNativeDateModule,
    FormsModule,
    ReactiveFormsModule,
    FusionChartsModule,
    NgApexchartsModule

  ],
  providers: [ BuildingService,{ provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } }],
  bootstrap: [AppComponent]
})
export class AppModule { }
