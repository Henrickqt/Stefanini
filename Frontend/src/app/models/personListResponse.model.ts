import { Person } from "./person.model";

export interface PersonListResponse {
  success: boolean,
  data: {
    success: boolean,
    errors: string[],
    personObjects: Person[]
  }
}
