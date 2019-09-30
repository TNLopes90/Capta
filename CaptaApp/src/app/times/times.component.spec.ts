/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TimesComponent } from './times.component';

describe('TimesComponent', () => {
  let component: TimesComponent;
  let fixture: ComponentFixture<TimesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
