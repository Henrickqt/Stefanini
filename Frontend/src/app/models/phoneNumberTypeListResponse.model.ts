import { PhoneNumberType } from "./phonenumbertype.model";

export interface PhoneNumberTypeListResponse {
  success: boolean,
  data: {
    success: boolean,
    errors: string[],
    phoneNumberTypeObjects: PhoneNumberType[]
  }
}
