import { Player } from './player.model';

export interface Team {
  id: number,
  coach: string,
  year: number,
  players: Player[]
}