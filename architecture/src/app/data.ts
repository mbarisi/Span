
export interface DataDTO {
  name: string;
  lastName: string;
  postCode: string;
  city: string;
  phoneNumber: string;
  invalidFormat : boolean;
}

export interface Data {
  result: any;
  success: boolean;
  message: string;
  errors: any[];
}


