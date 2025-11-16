import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GerenciarEmprestimoComponent } from './gerenciar-emprestimos';

describe('GerenciarEmprestimoComponent', () => {
  let component: GerenciarEmprestimoComponent;
  let fixture: ComponentFixture<GerenciarEmprestimoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GerenciarEmprestimoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarEmprestimoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
