import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  public readonly baseUrlProject="https://localhost:5001/";
}
