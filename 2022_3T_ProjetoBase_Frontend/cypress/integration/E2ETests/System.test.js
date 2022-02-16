describe("Integração - OCR", () => {
    
    beforeEach(() => {
        cy.visit('http://localhost:3000')
    })

    it("Deve logar e inserir a imagem OCR, retornando o valor correto da mesma", ()=>{

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()

        cy.get('.input__login').first().type('lima@email.com')
        cy.get('.input__login').last().type('123456789')
        cy.get('#btn__login').click()

        cy.get('input[type=file]').first().selectFile('src/assets/tests/equipamento.jpeg')

        cy.wait(5000)

        cy.get('#codigoPatrimonio').should('have.value', '1202362')

        cy.get('#nomePatrimonio').type('Note')
        cy.get('#nomePatrimonio').should('have.value', 'Note')

        cy.get('input[type=file]').last().selectFile('src/assets/tests/note.jpg')
        cy.get('.btn__cadastro').click()

        cy.wait(3000)
        cy.get('.card div h4').last().should('have.text', 'Note')
        cy.get('.excluir').last().click();
    })
})