/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NationalParksComponent } from './NationalParks.component';

describe('NationalParksComponent', () => {
  let component: NationalParksComponent;
  let fixture: ComponentFixture<NationalParksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NationalParksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NationalParksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
