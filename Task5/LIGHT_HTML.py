# Клас LightNode - базовий клас для елементів розмітки
class LightNode:
    pass

# Дочірній клас LightTextNode для текстових елементів
class LightTextNode(LightNode):
    def __init__(self, text):
        self.text = text

    def outerHTML(self):
        return self.text

# Дочірній клас LightElementNode для елементів з тегами
class LightElementNode(LightNode):
    def __init__(self, tag_name, display_type, closing_type, css_classes=None):
        self.tag_name = tag_name
        self.display_type = display_type
        self.closing_type = closing_type
        self.css_classes = css_classes if css_classes is not None else []
        self.children = []

    def add_child(self, child):
        self.children.append(child)

    def outerHTML(self):
        attributes = ' '.join([f'{key}="{value}"' for key, value in self.__dict__.items() if key != 'children'])
        children_html = ''.join([child.outerHTML() for child in self.children])
        if self.closing_type == 'single':
            return f'<{self.tag_name} {attributes}/>'
        else:
            return f'<{self.tag_name} {attributes}>{children_html}</{self.tag_name}>'

    def innerHTML(self):
        return ''.join([child.outerHTML() for child in self.children])

# Функція для демонстрації виводу сторінки у консоль
def show_page():
    # Створення сторінки за допомогою LightHTML
    page = LightElementNode('html', 'block', 'double')
    head = LightElementNode('head', 'block', 'double')
    title = LightElementNode('title', 'inline', 'double')
    title.add_child(LightTextNode('Моя HTML-сторінка'))
    body = LightElementNode('body', 'block', 'double', ['page-body'])

    header1 = LightElementNode('h1', 'block', 'double', ['header'])
    header1.add_child(LightTextNode('Це заголовок'))

    paragraph = LightElementNode('p', 'block', 'double', ['text'])
    paragraph.add_child(LightTextNode('Це абзац тексту'))

    unordered_list = LightElementNode('ul', 'block', 'double', ['list'])
    list_item1 = LightElementNode('li', 'block', 'double')
    list_item1.add_child(LightTextNode('Перший елемент списку'))
    list_item2 = LightElementNode('li', 'block', 'double')
    list_item2.add_child(LightTextNode('Другий елемент списку'))
    unordered_list.add_child(list_item1)
    unordered_list.add_child(list_item2)

    body.add_child(header1)
    body.add_child(paragraph)
    body.add_child(unordered_list)

    page.add_child(head)
    page.add_child(body)

    # Виведення сторінки у консоль
    print(page.outerHTML())

# Виклик функції для виводу сторінки у консоль
show_page()
