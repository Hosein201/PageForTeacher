export class Support {
    id:number;
    titel:string;
    message:string;
    isReadAdmin:boolean;
    answer:string;
    registerDate:Date
}

export class SupportCreate {
    titel:string;
    message:string;   
}

export class SupportUpdate {
    answer:string;
    id:number;   
}

export interface PeriodicElement {
    name: string;
    position: number;
    weight: number;
    symbol: string;
    
  }
  