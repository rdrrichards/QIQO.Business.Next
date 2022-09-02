import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Account[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Account[]>(baseUrl + 'weatherforecast').subscribe({
      next: result => { this.forecasts = result; },
      error: error => console.error(error)
    });
  }
}

export interface Account {
  accountKey: number;
  companyKey: number;
  accountType: number;
  accountCode: string;
  accountName: string;
  accountDesc: string;
  accountDba: string;
  accountStartDate: string;
  accountEndDate: string;
  addedUserID: string;
  addedDateTime: string;
  updateUserID: string;
  updateDateTime: string;
}
