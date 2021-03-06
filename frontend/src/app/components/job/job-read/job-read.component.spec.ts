import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobReadComponent } from './job-read.component';

describe('JobReadComponent', () => {
  let component: JobReadComponent;
  let fixture: ComponentFixture<JobReadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobReadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JobReadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
