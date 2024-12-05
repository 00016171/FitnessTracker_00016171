import { Activity } from "./activity.model";

export interface User {
    id: number;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    email: string;
    password: string;
    activities: Activity[];
  }
  