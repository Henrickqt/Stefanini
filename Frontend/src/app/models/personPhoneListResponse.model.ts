import { PersonPhone } from "./personphone.model";

export interface PersonPhoneListResponse {
  success: boolean,
  data: {
    success: boolean,
    errors: string[],
    personPhoneObjects: PersonPhone[]
  }
}
