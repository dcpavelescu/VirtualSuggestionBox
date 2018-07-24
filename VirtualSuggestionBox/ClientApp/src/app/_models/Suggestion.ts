import { Rate } from "./Rate";

export class Suggestion {
  subject: string;
  improvement: string;
  solution: string;
  date: Date;
  ratings: Rate[];
  category: string[];
  id: string;
}
