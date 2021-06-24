import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private router: Router) { }

  readonly menus: Array<PoMenuItem> = [
    { label: 'Home', action: this.onClickHome.bind(this) },
    { label: 'Vagas', action: this.onClickJobs.bind(this) }
  ];

  private onClickHome() {
    this.router.navigate(['']);
  }

  private onClickJobs() {
    this.router.navigate(['/jobs']);
  }

}
