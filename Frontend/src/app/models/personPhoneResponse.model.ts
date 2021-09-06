import { PersonPhone } from "./personphone.model";

export interface PersonPhoneResponse {
  success: boolean,
  data: {
    success: boolean,
    errors: string[],
    personPhoneObject: PersonPhone
  }
}
