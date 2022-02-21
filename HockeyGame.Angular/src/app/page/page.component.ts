import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page',
  template: `
    <div class="content rounded-xl shadow-lg p-6">
      <router-outlet></router-outlet>
    </div>
  `,
  styles: [`
  :host {
    display: flex;
    justify-content: center;
    padding: 50px 0;
  }
  
  .content {
    max-width: 800px;
    width: 100%;
    min-height: 500px;
    background-color: white;
  }`]
})
export class PageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
