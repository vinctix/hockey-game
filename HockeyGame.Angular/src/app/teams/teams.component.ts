import { Component, OnInit } from '@angular/core';
import { Team } from '../shared/models/team.model';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {

  team?: Team;
  isAddingPlayer = false;

  constructor() { }

  ngOnInit(): void {
  }

}
