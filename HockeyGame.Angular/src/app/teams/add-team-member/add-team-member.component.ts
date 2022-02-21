import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { finalize } from 'rxjs';
import { Team } from 'src/app/shared/models/team.model';
import { PlayersService } from 'src/app/shared/services/players.service';

@Component({
  selector: 'app-add-team-member',
  templateUrl: './add-team-member.component.html',
  styleUrls: ['./add-team-member.component.css']
})
export class AddTeamMemberComponent implements OnInit {

  @Input() team!: Team;
  @Output() finished = new EventEmitter<boolean>();

  form!: FormGroup;
  isLoading = false;
  private readonly durationSnackBarInSeconds = 3;

  constructor(
    private fb: FormBuilder,
    private playerService: PlayersService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.form = this.createForm();
  }

  private createForm(): FormGroup {
    return this.fb.group({
      teamId: [ this.team.id, []],
      number: [, Validators.required],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      position: ['', [Validators.required]],
      isCaptain: [false, []]
    });
  }

  submit() {
    this.form.markAllAsTouched();
    if(this.form.valid) {
      this.isLoading = true;
      this.playerService.createPlayer$(this.form.value)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe(() => {
        this.snackBar.openFromComponent(PlayerCreatedComponent, {
          duration: this.durationSnackBarInSeconds * 1000,
        });
        this.finished.emit(true);
      })
    }
  }

  cancel() {
    this.finished.emit(false);
  }

  get fcFirstName(): AbstractControl | null {
    return this.form.get('firstName');
  }

  get fcLastName(): AbstractControl | null {
    return this.form.get('lastName');
  }

  get fcPosition(): AbstractControl | null {
    return this.form.get('position');
  }

  get fcIsCaptain(): AbstractControl | null {
    return this.form.get('isCaptain');
  }

  get fcNumber(): AbstractControl | null {
    return this.form.get('number');
  }
}


@Component({
  template: `
    <span>
      Joueur ajouté avec succès! 🎉
    </span>
  `,
  styles: [':host { display: flex; justify-content: center  } ']
})
export class PlayerCreatedComponent implements OnInit {
  constructor() { }

  ngOnInit() { }
}
