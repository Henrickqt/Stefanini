import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertphoneComponent } from './insertphone.component';

describe('InsertphoneComponent', () => {
  let component: InsertphoneComponent;
  let fixture: ComponentFixture<InsertphoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsertphoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertphoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
