import { nationalpark } from './nationalpark';

export interface trails {
  id: number;
  name: string;
  distance: string;
  types: number;
  yala?: nationalpark[];
}
