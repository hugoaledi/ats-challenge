import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobCrudComponent } from './job-crud.component';

describe('JobCrudComponent', () => {
  let component: JobCrudComponent;
  let fixture: ComponentFixture<JobCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JobCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
